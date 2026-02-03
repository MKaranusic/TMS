import { useContext } from 'react';
import { TaskContext } from './TaskContextDef';

export function useTask() {
  const context = useContext(TaskContext);
  if (context === undefined) {
    throw new Error('useTask must be used within a TaskProvider');
  }
  return context;
}
