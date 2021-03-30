# Mongo API

***A template web API for MongoDB in dotnet 5***

## Mongo

Set up a Mongo database, would suggest running with Docker.

```bash
docker run \
    -p 27017:27017 \
    -e MONGO_INITDB_ROOT_USERNAME="root" \
    -e MONGO_INITDB_ROOT_PASSWORD="password" \
    -v /home/localpath/data:/data/db \
    -d mongo:4.4.4
```

Make sure volume isn't bound to container before passing environment variables, otherwise root user won't be saved.
