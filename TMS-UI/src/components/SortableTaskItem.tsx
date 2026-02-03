import { useSortable } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import type { TaskDto } from '../types/Task';

interface SortableTaskItemProps {
  task: TaskDto;
  onToggleComplete: (task: TaskDto) => void;
  onView: (task: TaskDto) => void;
  onEdit: (task: TaskDto) => void;
  onDelete: (id: number) => void;
}

export function SortableTaskItem({
  task,
  onToggleComplete,
  onView,
  onEdit,
  onDelete,
}: SortableTaskItemProps) {
  const {
    attributes,
    listeners,
    setNodeRef,
    transform,
    transition,
    isDragging,
  } = useSortable({ id: task.id });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition,
    opacity: isDragging ? 0.5 : 1,
  };

  return (
    <li
      ref={setNodeRef}
      style={style}
      className={`myth-task-item ${task.isCompleted ? 'completed' : ''} ${isDragging ? 'dragging' : ''}`}
    >
      <div className="myth-drag-handle" {...attributes} {...listeners}>
        <span className="myth-drag-icon">⋮⋮</span>
      </div>
      <input
        type="checkbox"
        className="myth-checkbox"
        checked={task.isCompleted}
        onChange={() => onToggleComplete(task)}
      />
      <div className="myth-task-content" onClick={() => onView(task)} style={{ cursor: 'pointer' }}>
        <p className={`myth-task-subject ${task.isCompleted ? 'completed' : ''}`}>
          {task.subject}
        </p>
        {task.description && (
          <p className="myth-task-description myth-task-description-truncate">{task.description}</p>
        )}
      </div>
      <div className="myth-task-actions">
        <button
          className="myth-button myth-button-secondary myth-button-small"
          onClick={() => onView(task)}
        >
          View
        </button>
        <button
          className="myth-button myth-button-secondary myth-button-small"
          onClick={() => onEdit(task)}
        >
          Edit
        </button>
        <button
          className="myth-button myth-button-danger myth-button-small"
          onClick={() => onDelete(task.id)}
        >
          Delete
        </button>
      </div>
    </li>
  );
}
