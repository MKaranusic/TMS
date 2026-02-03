import { TaskProvider } from './context/TaskProvider';
import TaskList from './components/TaskList';

function App() {
  return (
    <TaskProvider>
      <div>
        <TaskList />
      </div>
    </TaskProvider>
  );
}

export default App;
