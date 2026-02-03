import type { TaskDto } from '../types/Task';

export const PAGE_SIZE = 5;

export type FilterType = 'all' | 'completed' | 'pending';

export interface TaskContextType {
  // State
  tasks: TaskDto[];
  loading: boolean;
  listLoading: boolean;
  error: string | null;
  filter: FilterType;
  currentPage: number;
  totalPages: number;
  totalCount: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;

  // Actions
  fetchTasks: (filter?: FilterType, page?: number, isInitial?: boolean) => Promise<void>;
  setFilter: (filter: FilterType) => void;
  createTask: (subject: string, description?: string) => Promise<boolean>;
  updateTask: (id: number, subject: string, description?: string, isCompleted?: boolean) => Promise<boolean>;
  deleteTask: (id: number) => Promise<boolean>;
  toggleTaskComplete: (task: TaskDto) => Promise<boolean>;
  goToPage: (page: number) => void;
  clearError: () => void;
  reorderTasks: (activeId: number, overId: number) => Promise<void>;
}
