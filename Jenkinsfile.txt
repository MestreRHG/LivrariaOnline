pipeline 
{
    agent any
    environment {
        Connectionstring_DefaultConnection = 'Server=localhost,8002; Database=LivrariaOnline; User Id=sa; Password=LivrariaXPTO123; Trust Server Certificate=True;'
    }

    stages 
    {
        stage('Checkout Stage') {
            steps {
                git url: 'https://github.com/MestreRHG/LivrariaOnline.git', branch: 'master'
            }
        }
        
        stage('Build Stage')  
        {
            steps 
            {
                bat 'dotnet build "%WORKSPACE%\\LivrariaOnline.sln" -c Release /p:PublishProfile="%WORKSPACE%\\LivrariaOnline\\Properties\\PublishProfiles\\FolderProfile.pubxml" /p:Platform="Any CPU" /p:DeployOnBuild=true /m' 
            }
        }
        
        stage('Deploy Stage')
        {
            steps
            {
            //Deploy application on IIS
            bat 'net stop "w3svc"'
            bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:package="%WORKSPACE%\\LivrariaOnline\\bin\\Release\\net8.0\\LivrariaOnline.zip" -dest:auto -setParam:"IIS Web Application Name"="JenkinsDemo" -skip:objectName=filePath,absolutePath=".\\\\PackagDemotap\\\\Web.config$" -enableRule:DoNotDelete -allowUntrusted=true'
            bat 'net start "w3svc"'

            }
        }
    }
}