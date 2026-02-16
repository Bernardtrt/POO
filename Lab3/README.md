# Lab 3: LINQ & Entity Framework (NixOS / CLI Edition)

## Context & Environment
This project was developed on **NixOS** (Linux). As the Windows Presentation Foundation (WPF) and Visual Studio are not natively available on this operating system, I have adapted the laboratory requirements to a cross-platform environment.

- **IDE:** VS Code / Terminal (CLI)
- **Framework:** .NET 8.0
- **Database:** SQLite (ported from the original Northwind SQL Server `.mdf`)
- **Interface:** Interactive Console Application

## Project Architecture
Instead of a WPF GUI, this project implements a **Console Menu System** that triggers the exact same LINQ logic and Entity Framework operations required by the lab sheet.

### Key Adaptations
| Original Requirement (WPF) | My Implementation (CLI) |
|----------------------------|-------------------------|
| `.MDF` SQL Server Database | `northwind.db` (SQLite) |
| Visual Studio Wizard (`.edmx`) | `dotnet ef` Scaffolding (Code First/Database First) |
| Buttons & Event Handlers | Switch/Case Menu System |
| DataGrid Display | Formatted Console Output |
| `ItemsSource` Binding | `foreach` loops printing to stdout |

## How to Run

### Prerequisites
- .NET SDK 8.0
- (Optional) Nix shell configured via `shell.nix`

### Setup & Execution
1. **Restore dependencies:**
   ```bash
   dotnet restore



My nix-shell if needed : 

shell.nix


{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  # Les paquets dont tu as besoin
  buildInputs = [
    pkgs.dotnet-sdk_8 # Choisis ta version (6, 7, 8...)
    pkgs.omnisharp-roslyn # Pour l'auto-complétion si tu utilises VS Code ou Vim
    pkgs.netcoredbg # Pour le débugging
    
    pkgs.dotnet-ef #pour le scrapping de sqlite 
  ];

  # Variables d'environnement pour que .NET ne s'y perde pas
  shellHook = ''
    export DOTNET_ROOT=${pkgs.dotnet-sdk_8}
    export PATH="$PATH:$HOME/.dotnet/tools"
    echo "🚀 Environnement .NET prêt ! SDK version: $(dotnet --version)"
  '';
}

