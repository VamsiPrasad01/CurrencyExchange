# 💱 Currency Exchange App (WCF + MAUI)

This is a full-stack Currency Exchange System built using a **WCF backend**, **SQL Server database**, and a **.NET MAUI frontend**. The app allows users to top up their PLN balance, buy/sell currencies based on live exchange rates, and track transaction history.

---

## 📦 Features

- ✅ **Top Up** your PLN balance
- ✅ **Buy/Sell** currency based on live NBP exchange rates
- ✅ View **current PLN balance**
- ✅ See live **wallet holdings** (USD, INR, etc.)
- ✅ Browse **transaction history**
- ✅ Responsive and user-friendly **MAUI mobile interface**
- ✅ Fully integrated with **WCF backend + EF database**

---

## 🧰 Technologies Used

| Layer       | Stack                      |
|-------------|----------------------------|
| Frontend    | .NET MAUI (XAML + C#)      |
| Backend     | WCF (WebHttpBinding, REST) |
| Database    | SQL Server (LocalDB) + EF  |
| Integration | HttpClient + JSON          |

---

## 🧪 How to Run the Project

### 🚀 Backend (WCF)

1. Open the solution in Visual Studio
2. Right-click the **solution → Set Startup Projects → Multiple startup projects**
3. Set:
   - `CurrencyExchangeBackend` → Start
   - `CurrencyExchangeFrontend` → Start
4. Run the solution (F5) — backend will open `Service1.svc`

### 📱 Frontend (MAUI)

- The MAUI app launches a mobile-style UI
- Navigate between:
  - 💰 Home (Balance + Top-Up)
  - 🔁 Exchange Page (Buy/Sell)
  - 📜 Transaction History

---

## 🔗 WCF Endpoints

| Operation            | Method | URL Example |
|----------------------|--------|-------------|
| Get PLN Balance      | GET    | `/GetPLNBalance` |
| Get Wallet Holdings  | GET    | `/GetCurrencyHoldings` |
| Top-Up Balance       | POST   | `/TopUpBalance?amount=500` |
| Buy Currency         | POST   | `/BuyCurrency?currencyCode=usd&plnAmount=100` |
| Sell Currency        | POST   | `/SellCurrency?currencyCode=usd&currencyAmount=2` |
| Transaction History  | GET    | `/GetTransactions` |

---

## 📸 Screenshots

| Screen               | Description                         |
|----------------------|-------------------------------------|
| 💰 Home              | Shows balance + top-up form         |
| 🔄 Exchange          | Currency picker, buy/sell buttons   |
| 📜 History           | List of all past transactions       |

> _Screenshots will be added before final submission._

---

## 📌 Developer Notes

- Uses `EnsureUserExists()` to simulate a logged-in default user
- Exchange rates are pulled from [NBP API](https://api.nbp.pl)
- Transactions and wallet holdings are persisted in SQL Server

---

## 🪪 License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

```

MIT License

Copyright (c) 2025

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND.

```

---

## 👤 Author

- **Attada Vamsi Prasad*
- Project for **Networking Application Development**
```
