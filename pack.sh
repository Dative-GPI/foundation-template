PACKAGES=$(find src -name "*.csproj")
OUTPUT_DIR=libs
NUGET_SOURCES="$HOME/.nuget/local-packages"

for package in $PACKAGES
do
    echo "Packing $package"
    dotnet pack $package -c Release -o $OUTPUT_DIR
done

LIBS=$(find $OUTPUT_DIR -name "*.nupkg")
for lib in $LIBS
do
    NAME=$(echo $lib | awk -F'.' '{OFS="."; print $1,$2,$3}')
    VERSION=$(echo $lib | awk -F'.' '{OFS="."; print $4,$5,$6}')
    nuget delete $(basename $NAME) $VERSION -s $NUGET_SOURCES -NonInteractive
    nuget add $lib -s $NUGET_SOURCES
done
