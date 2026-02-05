Encryption API
Ett API för kryptering och dekryptering med Caesar-chiffer, automatiskt distribuerat till AWS med en komplett CI/CD-pipeline.


📋 Innehållsförteckning

Funktioner
Teknologier
Projektstruktur
Installation
Användning
API-endpoints
Tester
Git Flow
CI/CD Pipeline
AWS-distribution


✨ Funktioner

✅ Kryptering av text med Caesar-chiffer
✅ Dekryptering av text
✅ Anpassningsbar förskjutning (shift)
✅ Automatiserade enhetstester (6 tester)
✅ CI/CD med GitHub Actions
✅ Automatisk distribution till AWS Elastic Beanstalk
✅ Swagger-dokumentation integrerad


🛠 Teknologier
TeknologiAnvändningC# / .NET 9Backend APIxUnitEnhetstesterGitHub ActionsCI/CD PipelineAWS Elastic BeanstalkHostingSwaggerAPI-dokumentation

📁 Projektstruktur
EncryptionAPI/
│
├── .github/
│   └── workflows/
│       └── ci-cd.yml              # CI/CD Pipeline
│
├── EncryptionAPI/                  # API-projekt
│   ├── Controllers/
│   │   └── CryptoController.cs    # API-endpoints
│   ├── Services/
│   │   ├── ICryptoService.cs      # Gränssnitt
│   │   └── CaesarCipherService.cs # Implementation
│   ├── Program.cs                 # Startpunkt
│   └── EncryptionAPI.csproj
│
├── EncryptionAPI.Tests/            # Enhetstester
│   ├── CaesarCipherTests.cs       # 6 tester
│   └── EncryptionAPI.Tests.csproj
│
├── .gitignore
├── README.md
└── EncryptionAPI.sln

🚀 Installation
Förutsättningar

.NET 9 SDK
Git

Klona projektet
bashgit clone https://github.com/Abdi-SalamIb/CICD-AWS.git
cd CICD-AWS
Återställ beroenden
bashdotnet restore
Starta API:et
bashcd EncryptionAPI
dotnet watch run
API:et kommer att vara tillgängligt på: http://localhost:5204

💻 Användning
Öppna Swagger
Öppna din webbläsare och gå till:
http://localhost:5204/swagger
Exempel på kryptering
Förfrågan:
jsonPOST /api/crypto/encrypt
{
  "text": "Hello World",
  "shift": 3
}
Svar:
json{
  "originalText": "Hello World",
  "resultText": "Khoor Zruog",
  "shift": 3,
  "operation": "Encryption"
}
Exempel på dekryptering
Förfrågan:
jsonPOST /api/crypto/decrypt
{
  "text": "Khoor Zruog",
  "shift": 3
}
Svar:
json{
  "originalText": "Khoor Zruog",
  "resultText": "Hello World",
  "shift": 3,
  "operation": "Decryption"
}

🔗 API-endpoints
MetodEndpointBeskrivningPOST/api/crypto/encryptKryptera textPOST/api/crypto/decryptDekryptera textGET/api/crypto/helloTest-endpoint
Förfrågningskropp (JSON)
json{
  "text": "string",   // Text att kryptera/dekryptera
  "shift": 3          // Förskjutning (1-25), standard: 3
}

🧪 Tester
Kör testerna
bashdotnet test
Förväntat resultat
Test summary: total: 6, failed: 0, succeeded: 6, skipped: 0
Inkluderade tester
TestBeskrivningEncrypt_WithShift3_ReturnsCorrectResultABC → DEFDecrypt_WithShift3_ReturnsCorrectResultDEF → ABCEncrypt_ThenDecrypt_ReturnsOriginalTextReversibilitetEncrypt_WithEmptyString_ReturnsEmptyStringTom strängEncrypt_PreservesNonLetterCharactersMellanslag och siffrorEncrypt_HandlesWrapAroundXYZ → ABC

🌿 Git Flow
Detta projekt använder Git Flow-strategin med 3 typer av grenar:
MAIN (produktion)    ════●════════════════════●════════► AWS
                         │                    ▲
                         │                    │ PR
                         │                    │
DEV (utveckling)     ────●────────●───────────●─────────►
                                  │           ▲
                                  │           │ PR
                                  │           │
FEATURE (funktion)   .............●───────────●
Grenar
GrenBeskrivningmainProduktion - Distribueras till AWSdevUtveckling - Integrationfeature/*Nya funktioner
Arbetsflöde

Skapa en feature/*-gren från dev
Utveckla funktionen
Pull Request: feature/* → dev
Pull Request: dev → main
Automatisk distribution till AWS


⚙️ CI/CD Pipeline
GitHub Actions pipeline körs automatiskt vid varje push.
Jobb
┌─────────────────────────────────────────────────────────┐
│                    BYGG & TESTA                         │
│  ✅ Checkout → ✅ Setup .NET → ✅ Bygg → ✅ Test (6)    │
└─────────────────────────────────────────────────────────┘
                         │
                         │ Om main + framgång
                         ▼
┌─────────────────────────────────────────────────────────┐
│                    DISTRIBUERA                          │
│  ✅ Publicera → ✅ ZIP → ✅ Distribuera till AWS        │
└─────────────────────────────────────────────────────────┘
Utlösare
HändelseGrenarÅtgärdpushmain, devBygg + Testpull_requestmain, devBygg + TestpushmainBygg + Test + Distribuera

☁️ AWS-distribution
Konfiguration
ParameterVärdeTjänstAWS Elastic BeanstalkApplikationencryption-apiMiljöEncryption-api-envRegioneu-north-1 (Stockholm)Plattform.NET Core on Linux
GitHub Secrets som krävs
SecretBeskrivningAWS_ACCESS_KEY_IDAWS-åtkomstnyckelAWS_SECRET_ACCESS_KEYAWS-hemlig nyckel
Produktions-URL
http://Encryption-api-env.xxxxxx.eu-north-1.elasticbeanstalk.com

📝 Caesar-chiffer
Caesar-chiffer är en substitutionskrypteringsmetod där varje bokstav förskjuts ett visst antal positioner i alfabetet.
Exempel med shift = 3
A B C D E F G H I J K L M N O P Q R S T U V W X Y Z
↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓
D E F G H I J K L M N O P Q R S T U V W X Y Z A B C

HELLO → KHOOR
WORLD → ZRUOG


👤 Författare
Abdi-SalamIb

GitHub: @Abdi-SalamIb


📄 Licens
Detta projekt är skapat som en del av en CI/CD-examination.