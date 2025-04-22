# LoginComponent-FullStack-
This App Contains LoginPage+Register Page+ Dashboard page having coded as fullstack using ASP.Net Web API backend and React Js using Frontend and Database using SQL server. With JWT Token Authentication and Authorization and using API.  Followed Repository Patterns.

# 🔐 LoginComponent-FullStack-

A full-stack user authentication system built with **React.js** (frontend) and **ASP.NET Core Web API** (backend) using **JWT authentication**.

---

## 🚀 Tech Stack

### 🧩 Frontend
- React.js (Hooks)
- Axios (for API calls)
- React Router DOM (for routing)

### 🧰 Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- MS SQL Server
- JWT Token Authentication

---

## 📁 Project Structure


/LoginApp ├── Client # React Frontend │ ├── Pages │ │ ├── Register.js │ │ └── Login.js │ └── App.js ├── AuthAppAPI # ASP.NET Core Web API │ ├── Controllers │ ├── Models │ ├── Services │ ├── Data │ └── Program.cs


---

## ✨ Features

- User Registration
- User Login
- JWT Token generation and validation
- Password Hashing
- Protected Route for updating credentials
- Role-based authorization support (extendable)

---

## 📦 Getting Started

### ✅ Backend Setup (ASP.NET Core API)

1. Navigate to the `AuthAppAPI` folder:
   cd AuthAppAPI
   
Update connection string in appsettings.json.

3. Run migrations and update database:
  dotnet ef database update
Start the API:
  dotnet run
✅ Frontend Setup (React.js)
Navigate to the Client folder:
  cd Client
Install dependencies:
  npm install
Start the React app:
  npm start
