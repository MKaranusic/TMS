import apiClient from './apiClient';
import {
  TaskDto,
  PaginatedResponse,
  TaskFilterRequest,
  CreateTaskRequest,
  UpdateTaskRequest,
} from '../types/task.types';

const TASK_ENDPOINT = '/task';

export const taskService = {
  getTasks: async (filter?: TaskFilterRequest): Promise<PaginatedResponse<TaskDto>> => {
    const params = new URLSearchParams();
    
    if (filter?.page) params.append('page', filter.page.toString());
    if (filter?.pageSize) params.append('pageSize', filter.pageSize.toString());
    if (filter?.isCompleted !== undefined && filter?.isCompleted !== null) {
      params.append('isCompleted', filter.isCompleted.toString());
    }

    const response = await apiClient.get<PaginatedResponse<TaskDto>>(
      `${TASK_ENDPOINT}?${params.toString()}`
    );
    return response.data;
  },

  getTaskById: async (id: number): Promise<TaskDto> => {
    const response = await apiClient.get<TaskDto>(`${TASK_ENDPOINT}/${id}`);
    return response.data;
  },

  createTask: async (request: CreateTaskRequest): Promise<TaskDto> => {
    const response = await apiClient.post<TaskDto>(TASK_ENDPOINT, request);
    return response.data;
  },

  updateTask: async (id: number, request: UpdateTaskRequest): Promise<TaskDto> => {
    const response = await apiClient.put<TaskDto>(`${TASK_ENDPOINT}/${id}`, request);
    return response.data;
  },

  toggleCompleted: async (id: number): Promise<TaskDto> => {
    const response = await apiClient.patch<TaskDto>(`${TASK_ENDPOINT}/${id}/toggle`);
    return response.data;
  },

  deleteTask: async (id: number): Promise<void> => {
    await apiClient.delete(`${TASK_ENDPOINT}/${id}`);
  },
};
