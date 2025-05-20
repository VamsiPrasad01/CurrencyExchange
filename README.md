# 💱 Currency Exchange System

A complete backend and console-based currency exchange application built using **WCF (Windows Communication Foundation)** and **Entity Framework** on the .NET Framework. The system integrates with the official **National Bank of Poland (NBP) API** for real-time exchange rates.

---

## ✅ Features

### 🛠️ Backend (WCF Service)
- Real-time exchange rates using [NBP API](http://api.nbp.pl/en.html)
- Buy/Sell currency with accurate conversion
- View current PLN balance
- View wallet holdings (multiple currencies)
- Record all transactions in a SQL database

### 💾 Database Integration (EF 6)
- Code-first Entity Framework
- Tracks users, wallets (currency holdings), and transactions
- Migrations used to auto-generate schema

### 🖥️ Console Client (Frontend)
- Connects to the WCF backend
- Allows:
  - Getting exchange rates
  - Buying and selling currencies
  - Viewing PLN balance
  - Viewing currency holdings

---

## 🧪 Tech Stack

- .NET Framework (WCF)
- Entity Framework 6 (Code-First)
- SQL Server LocalDB
- Visual Studio 2022
- C#

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/VamsiPrasad01/CurrencyExchange.git
```

### 2. Open the Solution

Open `CurrencyExchange.sln` in **Visual Studio**.

### 3. Run Migrations

Open **Package Manager Console** and run:

```powershell
Update-Database
```

This will create your database (LocalDB) with required tables.

### 4. Run the Solution

- Set both projects (`CurrencyExchangeBackend` and `ConsoleClient`) as startup
- Press `F5` to launch the WCF service and run the client

---

## 🧩 Architecture

```
ConsoleClient
   ↓
WCF Service (CurrencyExchangeBackend)
   ↓
EF Core → SQL Server (LocalDB)
   ↓
NBP API (for exchange rates)
```

---

## 📌 NBP API Sample

Example endpoint used:
```
https://api.nbp.pl/api/exchangerates/rates/a/usd?format=json
```

---

## 🎓 Academic Use

This project was built as part of a course lab to fulfill the following grading criteria:

- ✅ WCF Service (Grade 3)
- ✅ Database Integration (Grade +1)
- ⏳ Optional: Mobile App UI (for full 5/5 score)

---

## 📃 License

MIT License  
© 2025 Vamsi Prasad
