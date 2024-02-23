# API pre správu kníh v knižnici

Projekt je vytvorený v rámci technológie ASP.NET Core a používa Entity Framework Core na komunikáciu s Postgres databázou.

## Inštalácia

1. Naklonujte si tento repozitár na svoj lokálny počítač.
2. Nainštalujte .NET SDK 8.0.100, ak ešte nie je nainštalovaný.
3. Otvorte terminál v zložke projektu a spustite príkaz `dotnet restore`, aby sa nainštalovali všetky závislosti projektu.
4. Následne spustite príkaz `dotnet build`, aby sa zostavil projekt.

## Použitie

1. Spustite projekt pomocou príkazu `dotnet watch run`. Aplikácia by mala byť k dispozícii na adrese `https://localhost:5001`.

## Verejné endpointy

- **POST** `/api/books` - Vytvorenie novej knihy
- **GET** `/api/books/{id}` - Získanie detailov existujúcej knihy podľa ID
- **PUT** `/api/books/{id}` - Aktualizácia existujúcej knihy
- **DELETE** `/api/books/{id}` - Odstránenie knihy
- **POST** `/api/books/borrow` - Vytvorenie novej zapožičanej knihy
- **PUT** `/api/books/{id}/return` - Potvrdenie o vrátení vypožičanej knihy
