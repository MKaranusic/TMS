export interface TaskDto {
  id: number;
  subject: string;
  description: string | null;
  isCompleted: boolean;
}

export interface PaginatedResponse<T> {
  items: T[];
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}

export interface TaskFilterRequest {
  page?: number;
  pageSize?: number;
  isCompleted?: boolean | null;
}

export interface CreateTaskRequest {
  subject: string;
  description?: string | null;
}

export interface UpdateTaskRequest {
  subject: string;
  description?: string | null;
  isCompleted: boolean;
}
