{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  # Les paquets dont tu as besoin
  buildInputs = [
   
    pkgs.dotnet-sdk_8
    pkgs.omnisharp-roslyn
    pkgs.netcoredbg
    pkgs.sqlite
    pkgs.dotnet-ef
    # --- Les librairies graphiques pour l'interface Avalonia ---
    pkgs.fontconfig
    pkgs.freetype
    pkgs.xorg.libX11
    pkgs.xorg.libICE
    pkgs.xorg.libSM
    pkgs.libGL
    ]; 

  LD_LIBRARY_PATH = pkgs.lib.makeLibraryPath [
  pkgs.fontconfig
  pkgs.freetype
  pkgs.xorg.libX11
  pkgs.xorg.libICE
  pkgs.xorg.libSM
  pkgs.libGL
  ];
  # Variables d'environnement pour que .NET ne s'y perde pas
  shellHook = ''
    export DOTNET_ROOT=${pkgs.dotnet-sdk_8}
    export PATH="$PATH:$HOME/.dotnet/tools"
    echo "🚀 Environnement .NET prêt ! SDK version: $(dotnet --version)"
  '';
}
