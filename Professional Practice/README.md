# Professional Practice – Secure MongoDB Login System

## 🎥 Watch the Project Presentation & Demo below

<a href="https://www.youtube.com/watch?v=uripIPCbDrY" target="_blank">
  <img src="https://img.youtube.com/vi/uripIPCbDrY/0.jpg" alt="Secure Login Presentation and Demo" width="600"/>
</a>

This repository contains my final-year submission for the **Professional Practice** module at the University of Suffolk. The project focused on delivering a real-world solution to a live brief set by an external client. My role involved designing and implementing a secure authentication system using Unity and MongoDB, with JWT token-based login and refresh support.

---

## 🧠 Module Overview

This module simulates an industry brief by assigning students to client-driven challenges. It evaluates a developer's ability to:

- Understand and interpret real briefs  
- Plan, manage, and revise work based on feedback  
- Deliver robust, professional-grade outputs  

---

## 🔐 Project: Secure Login System (Unity + MongoDB + JWT)

### 🌍 Context:
The brief involved creating a secure and professional login flow for a digital product, with modern backend integration and best-practice security.

### 💡 Technologies Used:
- **Unity** (frontend and UI)
- **MongoDB** (cloud-based NoSQL user database)
- **JWT Tokens** (access + refresh logic)
- **C#** (custom script development)
- **AWS SDK** / Identity model libraries
- **TextMesh Pro** for polished UI/UX
- **External JSON config** for secure credentials

---

## 👨‍💻 Key Features

| Feature               | Description |
|------------------------|-------------|
| Login UI              | Secure, animated login screen with error handling |
| Token Auth System     | Access + refresh token lifecycle using JWT |
| MongoDB Integration   | Secure user data retrieval and login validation |
| Connectivity Checks   | Verifies internet and DB connectivity before login |
| UI Navigation         | Tab-based navigation via script |
| Config File Support   | External JSON config for MongoDB security details |
| Visuals               | Background visuals (`bg1.jpg`) and clean UI using **TextMesh Pro** |

---

## 📂 Folder Structure

```
Professional Practice/
│
├── SecureLoginProject/
│   ├── Assets/
│   │   ├── Fonts/
│   │   ├── Images/
│   │   ├── Plugins/         # DLL dependencies (MongoDB, AWS, JWT)
│   │   ├── Scenes/          # Contains SampleScene.unity
│   │   ├── Scripts/         # Core project logic
│   │   ├── StreamingAssets/ # Config file storage
│   │   └── TextMesh Pro/    # UI assets
│   └── mongodb_config.json.txt
│
├── Assessment Brief.pdf
├── Module Assessment Info_23.24.html
├── WeeklySummary&Postmortem.pdf
```

---

## 📁 Key Scripts Overview

| Script Name              | Purpose |
|--------------------------|---------|
| `LoginManager.cs`        | Main controller for UI + login logic |
| `CredentialsManager.cs`  | Holds username/password data |
| `JwtTokenGenerator.cs`   | Handles secure token creation |
| `JwtTokenValidator.cs`   | Validates tokens on login/session |
| `RefreshTokenManager.cs` | Manages refresh token lifecycle |
| `MongoDBManager.cs`      | Handles all DB interactions |
| `ConnectivityChecker.cs` | Ensures the app is online |
| `TabNavigation.cs`       | Switches between UI views |
| `MongoDBConfig.cs`       | Loads external credentials from config |

---

## 📊 Module Grades

| Assessment Component | Score  | Weight |
|----------------------|--------|--------|
| Portfolio Project     | 72%    | 80%    |
| Final Presentation    | 75%    | 20%    |
| **Final Grade**       | **72.40%** (First-Class) |

---

## 🎓 Academic Context

- **Module:** Professional Practice  
- **Course:** BSc (Hons) Games Development (Programming)  
- **Year:** Final (Level 6)  
- **University:** University of Suffolk  
- **Final Grade:** 72.40%

---

## 🙌 Final Thoughts

This project showcases:
- Ability to work with real-world briefs  
- Secure login integration with best practices  
- Technical depth in Unity–MongoDB connectivity  
- Clean, scalable UI using modern design standards  
