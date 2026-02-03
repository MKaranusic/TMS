import { useEffect, useState } from 'react';
import { TaskDto, PaginatedResponse } from '../types/task.types';
import { taskService } from '../api/taskService';

const TaskList = () => {
  const [tasks, setTasks] = useState<TaskDto[]>([]);
  const [pagination, setPagination] = useState<Omit<PaginatedResponse<TaskDto>, 'items'> | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchTasks = async (page: number = 1) => {
    try {
      setLoading(true);
      setError(null);
      const response = await taskService.getTasks({ page, pageSize: 10 });
      setTasks(response.items);
      setPagination({
        page: response.page,
        pageSize: response.pageSize,
        totalCount: response.totalCount,
        totalPages: response.totalPages,
        hasNextPage: response.hasNextPage,
        hasPreviousPage: response.hasPreviousPage,
      });
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to fetch tasks');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  if (loading) return <div>Loading tasks...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div>
      <h1>Tasks</h1>
      
      <p>
        Total: {pagination?.totalCount} | Page {pagination?.page} of {pagination?.totalPages}
      </p>

      <ul>
        {tasks.map((task) => (
          <li key={task.id}>
            <strong>{task.subject}</strong>
            {task.description && <p>{task.description}</p>}
            <span> - {task.isCompleted ? '? Completed' : '? Pending'}</span>
          </li>
        ))}
      </ul>

      <div>
        <button
          onClick={() => fetchTasks(pagination!.page - 1)}
          disabled={!pagination?.hasPreviousPage}
        >
          Previous
        </button>
        <button
          onClick={() => fetchTasks(pagination!.page + 1)}
          disabled={!pagination?.hasNextPage}
        >
          Next
        </button>
      </div>
    </div>
  );
};

export default TaskList;
