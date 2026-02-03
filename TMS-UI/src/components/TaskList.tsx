import { useState, useEffect } from 'react';
import { useTask } from '../context/useTask';
import type { TaskDto } from '../types/Task';
import './TaskList.css';

function TaskList() {
  const {
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
    fetchTasks,
    setFilter,
    createTask,
    updateTask,
    deleteTask,
    toggleTaskComplete,
    goToPage,
  } = useTask();

  // Local form state
  const [newTaskSubject, setNewTaskSubject] = useState('');
  const [newTaskDescription, setNewTaskDescription] = useState('');

  // Edit modal state
  const [editingTask, setEditingTask] = useState<TaskDto | null>(null);
  const [editSubject, setEditSubject] = useState('');
  const [editDescription, setEditDescription] = useState('');

  // View detail modal state
  const [viewingTask, setViewingTask] = useState<TaskDto | null>(null);

  // Initial fetch
  useEffect(() => {
    fetchTasks(filter, 1, true);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleAddTask = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!newTaskSubject.trim()) return;

    const success = await createTask(newTaskSubject, newTaskDescription || undefined);
    if (success) {
      setNewTaskSubject('');
      setNewTaskDescription('');
    }
  };

  const handleToggleComplete = async (task: TaskDto) => {
    await toggleTaskComplete(task);
  };

  const handleDeleteTask = async (id: number) => {
    await deleteTask(id);
  };

  const handleStartEdit = (task: TaskDto) => {
    setEditingTask(task);
    setEditSubject(task.subject || '');
    setEditDescription(task.description || '');
  };

  const handleCancelEdit = () => {
    setEditingTask(null);
    setEditSubject('');
    setEditDescription('');
  };

  const handleSaveEdit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!editingTask || !editSubject.trim()) return;

    const success = await updateTask(
      editingTask.id,
      editSubject,
      editDescription || undefined,
      editingTask.isCompleted
    );
    if (success) {
      handleCancelEdit();
    }
  };

  if (loading) {
    return (
      <div className="myth-container">
        <div className="myth-panel">
          <div className="myth-loading">
            <div className="myth-loading-spinner"></div>
            <div>Consulting the Oracle...</div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="myth-container">
      <div className="myth-panel">
        <h1 className="myth-title">Tasks</h1>
        <p className="myth-subtitle">Manage your tasks</p>

        <div className="myth-divider"></div>

        {error && <div className="myth-error">{error}</div>}

        <form className="myth-form-create" onSubmit={handleAddTask}>
          <div className="myth-form-row">
            <input
              type="text"
              className="myth-input"
              value={newTaskSubject}
              onChange={(e) => setNewTaskSubject(e.target.value)}
              placeholder="Task subject..."
              required
            />
            <button type="submit" className="myth-button">
              Create Task
            </button>
          </div>
          <textarea
            className="myth-textarea myth-textarea-small"
            value={newTaskDescription}
            onChange={(e) => setNewTaskDescription(e.target.value)}
            placeholder="Description (optional)..."
          />
        </form>

        <div className="myth-divider"></div>

        {/* Filter Buttons */}
        <div className="myth-filter-group">
          <span className="myth-filter-label">Filter:</span>
          <button
            type="button"
            className={`myth-filter-button ${filter === 'all' ? 'active' : ''}`}
            onClick={() => setFilter('all')}
          >
            All
          </button>
          <button
            type="button"
            className={`myth-filter-button ${filter === 'pending' ? 'active' : ''}`}
            onClick={() => setFilter('pending')}
          >
            Pending
          </button>
          <button
            type="button"
            className={`myth-filter-button ${filter === 'completed' ? 'active' : ''}`}
            onClick={() => setFilter('completed')}
          >
            Completed
          </button>
        </div>

        <div className="myth-divider"></div>

        {/* Edit Modal */}
        {editingTask && (
          <div className="myth-modal-overlay">
            <div className="myth-modal">
              <h2 className="myth-modal-title">Edit Task</h2>
              <form onSubmit={handleSaveEdit}>
                <div className="myth-form-group">
                  <label className="myth-label">Subject *</label>
                  <input
                    type="text"
                    className="myth-input myth-input-full"
                    value={editSubject}
                    onChange={(e) => setEditSubject(e.target.value)}
                    required
                  />
                </div>
                <div className="myth-form-group">
                  <label className="myth-label">Description</label>
                  <textarea
                    className="myth-textarea"
                    value={editDescription}
                    onChange={(e) => setEditDescription(e.target.value)}
                  />
                </div>
                <div className="myth-modal-actions">
                  <button
                    type="button"
                    className="myth-button myth-button-secondary"
                    onClick={handleCancelEdit}
                  >
                    Cancel
                  </button>
                  <button type="submit" className="myth-button">
                    Save
                  </button>
                </div>
              </form>
            </div>
          </div>
        )}

        {/* View Detail Modal */}
        {viewingTask && (
          <div className="myth-modal-overlay" onClick={() => setViewingTask(null)}>
            <div className="myth-modal myth-modal-detail" onClick={(e) => e.stopPropagation()}>
              <h2 className="myth-modal-title">Task Details</h2>
              <div className="myth-detail-status">
                <span className={`myth-status-badge ${viewingTask.isCompleted ? 'completed' : 'pending'}`}>
                  {viewingTask.isCompleted ? '✓ Completed' : '○ Pending'}
                </span>
              </div>
              <div className="myth-detail-section">
                <label className="myth-label">Subject</label>
                <p className="myth-detail-text">{viewingTask.subject}</p>
              </div>
              {viewingTask.description && (
                <div className="myth-detail-section">
                  <label className="myth-label">Description</label>
                  <p className="myth-detail-text myth-detail-description">{viewingTask.description}</p>
                </div>
              )}
              <div className="myth-modal-actions">
                <button
                  type="button"
                  className="myth-button myth-button-secondary"
                  onClick={() => setViewingTask(null)}
                >
                  Close
                </button>
                <button
                  type="button"
                  className="myth-button"
                  onClick={() => {
                    setViewingTask(null);
                    handleStartEdit(viewingTask);
                  }}
                >
                  Edit
                </button>
              </div>
            </div>
          </div>
        )}

        <div className={`myth-task-list-container ${listLoading ? 'loading' : ''}`}>
          {listLoading && (
            <div className="myth-list-loading">
              <div className="myth-loading-spinner-small"></div>
            </div>
          )}

          {tasks.length === 0 ? (
            <div className="myth-empty">
              <div className="myth-empty-icon">🏛️</div>
              <p>No tasks found.</p>
              <p>{filter === 'all' ? 'Begin by creating a new task above.' : 'No tasks match this filter.'}</p>
            </div>
          ) : (
            <ul className="myth-task-list">
              {tasks.map((task) => (
                <li key={task.id} className={`myth-task-item ${task.isCompleted ? 'completed' : ''}`}>
                  <input
                    type="checkbox"
                    className="myth-checkbox"
                    checked={task.isCompleted}
                    onChange={() => handleToggleComplete(task)}
                  />
                  <div className="myth-task-content" onClick={() => setViewingTask(task)} style={{ cursor: 'pointer' }}>
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
                      onClick={() => setViewingTask(task)}
                    >
                      View
                    </button>
                    <button
                      className="myth-button myth-button-secondary myth-button-small"
                      onClick={() => handleStartEdit(task)}
                    >
                      Edit
                    </button>
                    <button
                      className="myth-button myth-button-danger myth-button-small"
                      onClick={() => handleDeleteTask(task.id)}
                    >
                      Delete
                    </button>
                  </div>
                </li>
              ))}
            </ul>
          )}

          {/* Pagination Controls */}
          {totalPages > 1 && (
            <div className="myth-pagination">
              <button
                className="myth-button myth-button-secondary myth-button-small"
                onClick={() => goToPage(1)}
                disabled={!hasPreviousPage}
              >
                ««
              </button>
              <button
                className="myth-button myth-button-secondary myth-button-small"
                onClick={() => goToPage(currentPage - 1)}
                disabled={!hasPreviousPage}
              >
                «
              </button>
              <span className="myth-pagination-info">
                Page {currentPage} of {totalPages}
              </span>
              <button
                className="myth-button myth-button-secondary myth-button-small"
                onClick={() => goToPage(currentPage + 1)}
                disabled={!hasNextPage}
              >
                »
              </button>
              <button
                className="myth-button myth-button-secondary myth-button-small"
                onClick={() => goToPage(totalPages)}
                disabled={!hasNextPage}
              >
                »»
              </button>
            </div>
          )}

          {totalCount > 0 && (
            <div className="myth-pagination-total">
              Total: {totalCount} task{totalCount !== 1 ? 's' : ''}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default TaskList;
