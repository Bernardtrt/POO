{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  # Les paquets dont tu as besoin
  buildInputs = [
    pkgs.dotnet-sdk_8 # Choisis ta version (6, 7, 8...)
    pkgs.omnisharp-roslyn # Pour l'auto-complétion si tu utilises VS Code ou Vim
    pkgs.netcoredbg # Pour le débugging
  ];

  # Variables d'environnement pour que .NET ne s'y perde pas
  shellHook = ''
    export DOTNET_ROOT=${pkgs.dotnet-sdk_8}
    export PATH="$PATH:$HOME/.dotnet/tools"
    echo "🚀 Environnement .NET prêt ! SDK version: $(dotnet --version)"
  '';
}
