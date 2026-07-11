<!-- Central Header Banner -->
<div align="center">
  <img src="https://img.shields.io/badge/Language-C%23-green?style=for-the-badge&logo=c-sharp" alt="C# Badge" />
  <img src="https://img.shields.io/badge/Paradigm-OOP-blue?style=for-the-badge" alt="OOP Badge" />
  <img src="https://img.shields.io/badge/Architecture-Defensive-magenta?style=for-the-badge" alt="Defensive Badge" />
  
  <h1 style="color: #00ADB5; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-weight: bold; margin-top: 20px;">
     Crypto Wallet Simulator (v1.0)
  </h1>
  
  <p style="font-size: 1.2em; color: #EEEEEE;">
    A high-grade console simulation engine implementing rigorous Object-Oriented Programming and secure ledger logging.
  </p>
  
  <code style="color: #FFD369; font-size: 1.1em;">Developed with passion by: C#Fazza ++ 💻🎨</code>
</div>

<hr style="border: 1px solid #393E46;" />

## 🌟 Core Architecture & Features
This project serves as a comprehensive blueprint for core **C#** backend principles. It focuses on absolute data security and ironclad runtime protection against invalid state corruptions.

<ul>
  <li><strong>🔒 Advanced Encapsulation:</strong> Wallet properties (Balances, Owners, Crypto Tickers) are strictly protected via private access modifiers, preventing external illegal tampering.</li>
  <li><strong>🔄 Constructor Overloading:</strong> Offers dual-tier initialization routines—spin up tailored user portfolios or deploy instant default stablecoin backup wallets (0.0 USDT).</li>
  <li><strong>🛡️ Defensive Ledger Controls:</strong> Integrated defensive program design utilizing safe parsing routines (<code>double.TryParse</code>) to eliminate runtime exception crashes from negative numbers or string injection inputs.</li>
  <li><strong>📊 Live History Architecture:</strong> Leverages dynamic generic structures (<code>List&lt;string&gt;</code>) acting as an immutable local ledger logging system for real-time deposit and withdrawal execution tracing.</li>
</ul>

<hr style="border: 1px solid #393E46;" />

## 🛠️ Technical Specifications

<table width="100%">
  <thead>
    <tr style="background-color: #222831; color: #00ADB5;">
      <th align="left" style="padding: 10px;">Program Module</th>
      <th align="left" style="padding: 10px;">C# Concept Applied</th>
      <th align="left" style="padding: 10px;">Functional Benefit</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td style="padding: 10px;"><b>Wallet Class</b></td>
      <td style="padding: 10px;">Data Hiding & OOP Encapsulation</td>
      <td style="padding: 10px;">Secures money and state from unauthorized changes.</td>
    </tr>
    <tr>
      <td style="padding: 10px;"><b>Dual Constructors</b></td>
      <td style="padding: 10px;">Polymorphism (Overloading)</td>
      <td style="padding: 10px;">Flexible account initialization states.</td>
    </tr>
    <tr>
      <td style="padding: 10px;"><b>TransactionHistory</b></td>
      <td style="padding: 10px;">Generics & Collections (<code>List&lt;T&gt;</code>)</td>
      <td style="padding: 10px;">Dynamically grows and tracks system credits and debits.</td>
    </tr>
    <tr>
      <td style="padding: 10px;"><b>GetAmountFromUser</b></td>
      <td style="padding: 10px;">Data Validation & Loop Controls</td>
      <td style="padding: 10px;">Guarantees input numbers are strictly greater than zero.</td>
    </tr>
  </tbody>
</table>

<hr style="border: 1px solid #393E46;" />

## 🎮 Program Preview (How it Works)

```text
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$WELCOME TO CRYPTO WALLET SIMULATOR$
$             🚀 v1.0 🚀                  $
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

1. Instantiate Portfolios securely with boundary checks (BTC, ETH, USDT).
2. Execute Interactive Loop Menu (Deposit / Withdraw / Ignore).
3. Access Immuted Audit Reports and History Statements.
