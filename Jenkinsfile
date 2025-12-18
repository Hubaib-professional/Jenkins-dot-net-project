pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                echo '📦 Cloning repository...'
                checkout scm  // This line checks out your code
            }
        }
        
        stage('Setup .NET') {
            steps {
                echo '🔧 Setting up .NET environment...'
                // Use bat for Windows commands
                bat 'dotnet --version'
            }
        }
        
       stage('Restore') {
    steps {
        echo '📦 Restoring NuGet packages...'
        dir('src') {  // Changes to the 'src' subdirectory
            bat 'dotnet restore'
        }
    }
}
        
        stage('Build') {
            steps {
                echo '🔨 Building project...'
                bat 'dotnet build --configuration Release --no-restore'
            }
        }
        
        stage('Test') {
            steps {
                echo '🧪 Running tests...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }
    
    post {
        success {
            echo '✅ .NET Pipeline completed successfully!'
        }
        failure {
            echo '❌ Pipeline failed.'
        }
    }
}
