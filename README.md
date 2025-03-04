# Azure App Services Deployment

![Azure App Services](https://upload.wikimedia.org/wikipedia/commons/a/a8/Microsoft_Azure_Logo.svg)

## Overview
This repository demonstrates how to deploy an ASP.NET Core 9 application to **Azure App Services** using **GitHub Actions** for continuous integration and deployment (CI/CD).

## Features
- 🚀 **Azure App Services** for scalable web hosting.
- ⚡ **GitHub Actions** for automated build and deployment.
- 🛠 **ASP.NET Core 9** for modern web application development.

## Prerequisites
Before deploying, ensure you have the following:
- ✅ An **Azure Web App** instance set up.
- ✅ A **GitHub repository** with your ASP.NET Core 9 project.
- ✅ The **publish profile** of your Azure Web App (downloadable from the Azure portal).

## Setup Instructions
### 1. Configure Azure Web App
1. Log in to [Azure Portal](https://portal.azure.com).
2. Navigate to **App Services** and create a new Web App.
3. Select **.NET 9 (Core)** as the runtime stack.
4. Once created, download the **Publish Profile** from the Azure Web App settings.

### 2. Add GitHub Secret
1. Go to your GitHub repository.
2. Navigate to **Settings > Secrets and variables > Actions**.
3. Click **New repository secret**.
4. Name it **AZURE_WEBAPP_PUBLISH_PROFILE** and paste the contents of the publish profile.

### 3. GitHub Actions Workflow
The repository includes a **GitHub Actions** workflow (`.github/workflows/deploy.yml`) that automates:
- 🔹 Checking out the code.
- 🔹 Setting up .NET 9.
- 🔹 Building and publishing the app.
- 🔹 Deploying to **Azure App Services**.

### Example GitHub Actions Workflow
```yaml
name: Build and Deploy to Azure

on:
  push:
    branches: ["main"]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout code
        uses: actions/checkout@v4
      - name: Set up .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '9.0'
      - name: Build and Publish
        run: |
          dotnet build --configuration Release
          dotnet publish -c Release -o myapp
      - name: Upload Artifact
        uses: actions/upload-artifact@v4
        with:
          name: app
          path: myapp
  deploy:
    needs: build
    runs-on: ubuntu-latest
    steps:
      - name: Download Artifact
        uses: actions/download-artifact@v4
        with:
          name: app
      - name: Deploy to Azure
        uses: azure/webapps-deploy@v2
        with:
          app-name: ${{ secrets.AZURE_WEBAPP_NAME }}
          publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
          package: myapp
```

## Deployment
Push any changes to the `main` branch, and GitHub Actions will automatically build and deploy the application.

## Resources
📚 **Further Reading**:
- [Azure App Services](https://learn.microsoft.com/en-us/azure/app-service/)
- [GitHub Actions for Azure](https://learn.microsoft.com/en-us/azure/app-service/deploy-github-actions)
- [ASP.NET Core 9 Documentation](https://learn.microsoft.com/en-us/aspnet/core/)


