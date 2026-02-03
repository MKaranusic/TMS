import axios from 'axios';
import { API_BASE_URL } from '../config/api';
import type { TaskDto, CreateTaskRequest, UpdateTaskRequest, PaginatedResponse, GetTasksParams, ReorderTasksRequest } from '../types/Task';

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const taskApi = {
  getAll: async (params?: GetTasksParams): Promise<PaginatedResponse<TaskDto>> => {
    const response = await apiClient.get<PaginatedResponse<TaskDto>>('/Task', { params });
    return response.data;
  },

  getById: async (id: number): Promise<TaskDto> => {
    const response = await apiClient.get<TaskDto>(`/Task/${id}`);
    return response.data;
  },

  create: async (task: CreateTaskRequest): Promise<TaskDto> => {
    const response = await apiClient.post<TaskDto>('/Task', task);
    return response.data;
  },

  update: async (id: number, task: UpdateTaskRequest): Promise<TaskDto> => {
    const response = await apiClient.put<TaskDto>(`/Task/${id}`, task);
    return response.data;
  },

  delete: async (id: number): Promise<void> => {
    await apiClient.delete(`/Task/${id}`);
  },

  toggleComplete: async (id: number): Promise<TaskDto> => {
    const response = await apiClient.patch<TaskDto>(`/Task/${id}/toggle`);
    return response.data;
  },

  reorder: async (taskIds: number[]): Promise<void> => {
    await apiClient.put('/Task/reorder', { taskIds } as ReorderTasksRequest);
  },
};
