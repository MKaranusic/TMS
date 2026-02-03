// TaskDto from API
export interface TaskDto {
  id: number;
  subject: string | null;
  description: string | null;
  isCompleted: boolean;
}

// CreateTaskRequest - subject is required
export interface CreateTaskRequest {
  subject: string;
  description?: string | null;
}

// UpdateTaskRequest - subject is required
export interface UpdateTaskRequest {
  subject: string;
  description?: string | null;
  isCompleted: boolean;
}

// TaskDtoPaginatedResponse
export interface PaginatedResponse<T> {
  items: T[] | null;
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}

// Query parameters for GET /api/Task
export interface GetTasksParams {
  Page?: number;
  PageSize?: number;
  IsCompleted?: boolean;
}
