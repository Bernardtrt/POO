{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  buildInputs = with pkgs; [
    dotnetCorePackages.sdk_8_0
    jdk17
    android-tools
    zlib
    icu
    xorg.libICE
    xorg.libSM
    xorg.libX11
    xorg.libXcursor
    xorg.libXi
    xorg.libXrandr
    fontconfig
    libGL
  ];

  shellHook = ''
    export LD_LIBRARY_PATH=${pkgs.lib.makeLibraryPath (with pkgs; [
      xorg.libICE
      xorg.libSM
      xorg.libX11
      xorg.libXcursor
      xorg.libXi
      xorg.libXrandr
      fontconfig
      libGL
      zlib
      icu
    ])}:$LD_LIBRARY_PATH
    
    export DOTNET_ROOT=$PWD/.dotnet_sdk
    
    if [ ! -d "$DOTNET_ROOT" ]; then
      echo "📦 Clonage PROFOND du SDK .NET en local (résolution des pointeurs)..."
      mkdir -p $DOTNET_ROOT
      
      # LE FIX EST ICI : On utilise -rL pour faire une copie par VALEUR et non par RÉFÉRENCE
      cp -rL ${pkgs.dotnetCorePackages.sdk_8_0}/* $DOTNET_ROOT/
      
      chmod -R +w $DOTNET_ROOT
    fi
    
    export PATH=$DOTNET_ROOT:$PATH
    
    echo "======================================================="
    echo "✅ Environnement prêt (en copie profonde) !"
    echo "🛠️  Tu peux relancer : dotnet workload install maui"
    echo "======================================================="
  '';
}