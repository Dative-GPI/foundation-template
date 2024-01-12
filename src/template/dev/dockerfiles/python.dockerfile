FROM alpine as proj-env

WORKDIR /app

COPY . .

# On supprime tous les fichiers excepté les requirements.txt
RUN find . ! -name 'requirements.txt' -type f -exec rm -f {} +

# On supprime les dossiers qui servent plus à rien
RUN find . -type d -empty -delete

FROM python:3-slim

ARG PROJECT

WORKDIR /app/$PROJECT

COPY --from=proj-env /app /app

RUN pip install -r requirements.txt

COPY . /app

ENTRYPOINT python main.py