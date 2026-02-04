# Task Management System (TMS)

A full-stack task management application built with .NET 8 and React.

---

##  Quick Start

### Option 1: One-Click Launch (Easiest)

**Prerequisites:** [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed and running

1. Download these 2 files (keep them in the same folder):
   - [`docker-compose.prod.yml`](docker-compose.prod.yml)
   - [`start-tms.bat`](start-tms.bat)

2. Double-click `start-tms.bat`

3. The app opens automatically at http://localhost:3000

To stop: download and run [`stop-tms.bat`](stop-tms.bat)

>  This pulls pre-built images from [Docker Hub](https://hub.docker.com/u/mislavk). The images contain only the compiled application code - no secrets or sensitive data.

>  NOTE: if there is not data in the UI, refresh (FE could load faster than FE)

---

### Option 2: Build from Source (More Control)

If you prefer to build the images yourself instead of downloading pre-built ones:

**Prerequisites:** [Docker Desktop](https://www.docker.com/products/docker-desktop/) + [Git](https://git-scm.com/downloads)

```bash
git clone https://github.com/MKaranusic/TMS.git
cd TMS
docker compose up --build
```

- **Frontend**: http://localhost:3000
- **API Docs**: http://localhost:5000/swagger

To stop: `Ctrl+C` or `docker compose down`

---

### Option 3: Run Without Docker

If you don't have Docker and don't want to install it:

**Prerequisites:**
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 20+](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express/LocalDB)

**Step 1: Setup Database**

Update the connection string in `TMS/TMS.API/appsettings.json` to point to your SQL Server instance.

**Step 2: Run Backend**
```bash
cd TMS/TMS.API
dotnet run --launch-profile "TMS.DEV"
```
API runs at: https://localhost:7284

**Step 3: Run Frontend**
```bash
cd TMS-UI
npm install
npm run dev
```
UI runs at: http://localhost:5173

---

##  Features

### Task Management
- **Create Tasks** - Add new tasks with a subject and optional description
- **Edit Tasks** - Update task details inline
- **Delete Tasks** - Remove tasks you no longer need
- **Mark Complete/Incomplete** - Toggle task completion status with a single click
- **Drag & Drop Reordering** - Organize tasks by dragging them into your preferred order

### Filtering & Pagination
- **Filter by Status** - View all tasks, only completed, or only pending
- **Paginated List** - Navigate through tasks with page controls

---