import { createContext } from 'react';
import type { TaskContextType } from './TaskContextTypes';

export const TaskContext = createContext<TaskContextType | undefined>(undefined);
