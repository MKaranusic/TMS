import { useState, useCallback } from 'react';
import type { ReactNode } from 'react';
import { taskApi } from '../api/taskApi';
import type { TaskDto } from '../types/Task';
import { TaskContext } from './TaskContextDef';
import { PAGE_SIZE } from './TaskContextTypes';
import type { FilterType, TaskContextType } from './TaskContextTypes';

interface TaskProviderProps {
  children: ReactNode;
}

export function TaskProvider({ children }: TaskProviderProps) {
  // Task list state
  const [tasks, setTasks] = useState<TaskDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [listLoading, setListLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // Filter state
  const [filter, setFilterState] = useState<FilterType>('all');

  // Pagination state
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [totalCount, setTotalCount] = useState(0);
  const [hasNextPage, setHasNextPage] = useState(false);
  const [hasPreviousPage, setHasPreviousPage] = useState(false);

  const fetchTasks = useCallback(async (
    currentFilter: FilterType = filter,
    page: number = currentPage,
    isInitial = false
  ) => {
    try {
      if (isInitial) {
        setLoading(true);
      } else {
        setListLoading(true);
      }
      setError(null);

      const params = {
        Page: page,
        PageSize: PAGE_SIZE,
        ...(currentFilter !== 'all' && { IsCompleted: currentFilter === 'completed' }),
      };

      const response = await taskApi.getAll(params);
      setTasks(response.items || []);
      setTotalPages(response.totalPages);
      setTotalCount(response.totalCount);
      setHasNextPage(response.hasNextPage);
      setHasPreviousPage(response.hasPreviousPage);
      setCurrentPage(response.page);
    } catch (err) {
      setError('Failed to fetch tasks. Make sure the API is running.');
      console.error('Error fetching tasks:', err);
    } finally {
      setLoading(false);
      setListLoading(false);
    }
  }, [filter, currentPage]);

  const setFilter = useCallback((newFilter: FilterType) => {
    setFilterState(newFilter);
    fetchTasks(newFilter, 1);
  }, [fetchTasks]);

  const createTask = useCallback(async (subject: string, description?: string): Promise<boolean> => {
    try {
      await taskApi.create({
        subject,
        description: description || undefined,
      });
      // Refresh to show the new task
      await fetchTasks(filter, 1);
      return true;
    } catch (err) {
      setError('Failed to create task.');
      console.error('Error creating task:', err);
      return false;
    }
  }, [filter, fetchTasks]);

  const updateTask = useCallback(async (
    id: number,
    subject: string,
    description?: string,
    isCompleted?: boolean
  ): Promise<boolean> => {
    try {
      const task = tasks.find(t => t.id === id);
      if (!task) return false;

      const updatedTask = await taskApi.update(id, {
        subject,
        description: description || undefined,
        isCompleted: isCompleted ?? task.isCompleted,
      });
      setTasks(prev => prev.map(t => (t.id === id ? updatedTask : t)));
      return true;
    } catch (err) {
      setError('Failed to update task.');
      console.error('Error updating task:', err);
      return false;
    }
  }, [tasks]);

  const deleteTask = useCallback(async (id: number): Promise<boolean> => {
    try {
      await taskApi.delete(id);
      // Refresh current page, or go to previous page if this was the last item
      const shouldGoBack = tasks.length === 1 && currentPage > 1;
      await fetchTasks(filter, shouldGoBack ? currentPage - 1 : currentPage);
      return true;
    } catch (err) {
      setError('Failed to delete task.');
      console.error('Error deleting task:', err);
      return false;
    }
  }, [tasks.length, currentPage, filter, fetchTasks]);

  const toggleTaskComplete = useCallback(async (task: TaskDto): Promise<boolean> => {
    try {
      const updatedTask = await taskApi.toggleComplete(task.id);
      // If filter is active and task status changed, refresh the list
      if (filter !== 'all') {
        await fetchTasks(filter, currentPage);
      } else {
        setTasks(prev => prev.map(t => (t.id === task.id ? updatedTask : t)));
      }
      return true;
    } catch (err) {
      setError('Failed to update task.');
      console.error('Error updating task:', err);
      return false;
    }
  }, [filter, currentPage, fetchTasks]);

  const goToPage = useCallback((page: number) => {
    if (page >= 1 && page <= totalPages) {
      fetchTasks(filter, page);
    }
  }, [totalPages, filter, fetchTasks]);

  const clearError = useCallback(() => {
    setError(null);
  }, []);

  const reorderTasks = useCallback(async (activeId: number, overId: number) => {
    const oldIndex = tasks.findIndex(t => t.id === activeId);
    const newIndex = tasks.findIndex(t => t.id === overId);
    
    if (oldIndex === -1 || newIndex === -1) return;
    
    // Optimistically update UI
    const newTasks = [...tasks];
    const [movedTask] = newTasks.splice(oldIndex, 1);
    newTasks.splice(newIndex, 0, movedTask);
    setTasks(newTasks);
    
    // Persist to backend - send task IDs in desired display order (first ID appears first)
    try {
      const taskIds = newTasks.map(t => t.id);
      await taskApi.reorder(taskIds);
      // Refresh task list from server to get updated SortOrder values
      await fetchTasks(filter, currentPage);
    } catch (err) {
      // Revert on error
      setTasks(tasks);
      setError('Failed to save task order.');
      console.error('Error reordering tasks:', err);
    }
  }, [tasks, filter, currentPage, fetchTasks]);

  const value: TaskContextType = {
    // State
    tasks,
    loading,
    listLoading,
    error,
    filter,
    currentPage,
    totalPages,
    totalCount,
    hasNextPage,
    hasPreviousPage,

    // Actions
    fetchTasks,
    setFilter,
    createTask,
    updateTask,
    deleteTask,
    toggleTaskComplete,
    goToPage,
    clearError,
    reorderTasks,
  };

  return (
    <TaskContext.Provider value={value}>
      {children}
    </TaskContext.Provider>
  );
}
