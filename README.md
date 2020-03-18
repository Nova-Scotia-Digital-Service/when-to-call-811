# When to call 811 about COVID-19

Self-assesment tool to find out if you should call 811 about COVID-19 for the citizens of Nova Scotia, Canada.

## Requirements

The code and middleware is built using [.Net Core 2.1](https://en.wikipedia.org/wiki/.NET_Core).

For Docker please make sure you have access to Microsoft container registry.

| URL | TCP port |
|-----|----------|
|mcr.microsoft.com|443|

## Installation

This app is setup to work with [OpenShift s2i](https://github.com/redhat-developer/s2i-dotnetcore) buildpacks.

See [OpenShift instructions](https://docs.openshift.com/container-platform/4.3/applications/application_life_cycle_management/creating-applications-using-cli.html#remote) on application deployment.

You can also build this app with [Docker Desktop](https://www.docker.com/products/docker-desktop)

1. To compile the app and build the container image

    ```bash
    docker build . -t onlineassessment
    ```

2. To run the application locally on port 8080

    ```bash
    docker run -p 8080:80 onlineassessment
    ```

The site will be accessible via browser at [http://localhost:8080](http://localhost:8080)
