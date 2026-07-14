# 🚀 MatchVagas

> **Uma plataforma inteligente para agregação, análise e recomendação de vagas utilizando Inteligência Artificial.**

A **MatchVagas** é uma aplicação Full Stack inspirada em plataformas como LinkedIn Jobs, Glassdoor, Indeed e Wellfound. Seu objetivo é centralizar vagas de diversas fontes, processá-las automaticamente, enriquecê-las com Inteligência Artificial e oferecer recomendações altamente personalizadas para cada usuário.

O projeto foi desenvolvido utilizando uma arquitetura baseada em microsserviços, processamento assíncrono, filas de mensagens, cache distribuído e eventos, simulando a estrutura utilizada por grandes plataformas de recrutamento em ambientes de produção.

---

## ✨ Principais Funcionalidades

* 🔍 Agregação automática de vagas de múltiplas plataformas
* 🤖 Enriquecimento de dados com Inteligência Artificial
* 🎯 Sistema inteligente de matching entre candidatos e vagas
* 📄 Parser automático de currículos (PDF/DOCX)
* 📑 Extração de informações de descrições de vagas
* 📬 Sistema de alertas personalizados
* 📊 Dashboard analítico com métricas do mercado
* ⭐ Favoritos e histórico de candidaturas
* 📈 Estatísticas sobre tecnologias, salários e empresas
* 🔔 Notificações em tempo real

---

# 🏗 Arquitetura

O sistema foi dividido em serviços independentes para garantir escalabilidade, manutenção e alta disponibilidade.

```text
                +----------------------+
                |      Frontend        |
                |      Angular         |
                +----------+-----------+
                           |
                    API Gateway (C#)
                           |
        ------------------------------------------------
        |              |              |                |
 Scraper Service   Job Service    AI Service   Notification Service
        |              |              |                |
        -------------------------------
                       |
                PostgreSQL
                       |
        Redis • RabbitMQ/Kafka • Object Storage
```

## 🔹 API Gateway

Responsável por centralizar todas as requisições da plataforma.

**Funcionalidades**

* Autenticação JWT
* Autorização baseada em Roles
* Rate Limiting
* Validação
* Segurança
* Exposição da API REST

---

## 🔹 Scraper Service

Serviço responsável pela coleta automática de vagas.

**Responsabilidades**

* Crawlers periódicos
* Coleta em múltiplas fontes
* Logs de execução
* Publicação de eventos
* Monitoramento de falhas

---

## 🔹 Job Processing Service

Processa todas as vagas coletadas.

**Responsabilidades**

* Normalização dos dados
* Remoção de duplicidades
* Padronização de salários
* Normalização de tecnologias
* Associação com empresas
* Enriquecimento dos dados

---

## 🔹 AI Service

Motor responsável por todas as funcionalidades inteligentes.

### Recursos

* Resume Parser
* Job Parser
* Skill Extraction
* Salary Prediction
* Matching Engine
* Career Coach
* Cover Letter Generator
* ATS Resume Optimizer

---

## 🔹 Notification Service

Responsável pelas notificações da plataforma.

* Emails
* Alertas personalizados
* Novas vagas
* Recomendações
* Webhooks

---

# 🧠 Inteligência Artificial

A IA é utilizada durante todo o fluxo da aplicação para enriquecer informações e melhorar a experiência do usuário.

## Resume Parser

Extrai automaticamente:

* Experiência profissional
* Tecnologias
* Certificações
* Formação
* Idiomas
* Tempo de experiência

---

## Job Parser

Analisa descrições de vagas identificando:

* Tecnologias
* Senioridade
* Benefícios
* Idiomas
* Escolaridade
* Modalidade de contratação

---

## AI Match

Calcula automaticamente a compatibilidade entre candidato e vaga.

O algoritmo considera:

* Skills
* Experiência
* Senioridade
* Idiomas
* Preferências
* Localização
* Benefícios desejados

Resultado:

* Compatibilidade (%)
* Pontos fortes
* Competências ausentes
* Ranking das melhores vagas
* Justificativa da pontuação

---

## Career Coach

Analisa tendências do mercado e sugere:

* Tecnologias em alta
* Cursos
* Certificações
* Competências recomendadas

---

## Salary Prediction

Estima salários para vagas sem faixa salarial utilizando dados históricos semelhantes.

---

## ATS Resume Optimizer

Analisa currículos utilizando critérios semelhantes aos ATS utilizados por recrutadores.

Retorna:

* Score ATS
* Palavras-chave ausentes
* Melhorias recomendadas
* Compatibilidade com vagas

---

# 🗄 Modelagem de Dados

A plataforma foi projetada utilizando PostgreSQL com um modelo altamente normalizado e preparado para grandes volumes de dados.

### Principais Entidades

* 👤 Users
* 🏢 Companies
* 💼 Jobs
* 🛠 Skills
* 🎁 Benefits
* 🌎 Languages
* 📄 Resumes
* ❤️ Favorites
* 📬 Alerts
* 📊 Analytics
* 📈 Job History
* 📌 Applications

---

# 🔄 Fluxo de Processamento

```text
Scrapers
     │
     ▼
Fila de Mensagens
     │
     ▼
Job Processing
     │
     ▼
Normalização
     │
     ▼
IA (Parser + Matching)
     │
     ▼
Banco de Dados
     │
     ▼
API Gateway
     │
     ▼
Frontend
```

---

# 📊 Dashboard

O dashboard fornece uma visão completa do mercado de trabalho.

### Indicadores

* Total de vagas
* Empresas cadastradas
* Salário médio
* Tecnologias mais requisitadas
* Distribuição geográfica
* Vagas por senioridade
* Evolução do mercado
* Compatibilidade média
* Performance dos scrapers
* Alertas enviados

---

# ⚙️ Tecnologias

## Backend

* C#
* .Net
* EntityFramework
* REST API
* JWT
* PostgreSQL

## Inteligência Artificial

* NLP
* Resume Parser
* Job Parser
* Matching Engine
* Recommendation Engine
* Salary Prediction

## Infraestrutura

* Docker
* Docker Compose
* Arquitetura Orientada a Eventos
* Processamento Assíncrono
* Logs Centralizados

## Frontend

* Angular
* Angular Material
* RxJS
* Charts
* Dashboard Responsivo

---

# 🚀 Diferenciais

* Arquitetura baseada em microsserviços
* Processamento assíncrono com filas
* Agregação automática de vagas
* Remoção inteligente de duplicidades
* Sistema avançado de recomendação com IA
* Parser automático de currículos e vagas
* Dashboard analítico completo
* Histórico de candidaturas
* Alertas personalizados
* Modelo de dados altamente escalável
* Cache distribuído com Redis
* Preparado para ambientes de produção

---

# 📌 Objetivos do Projeto

Este projeto foi desenvolvido para demonstrar conhecimentos em:

* Arquitetura de Software
* Microsserviços
* Desenvolvimento Full Stack
* Modelagem avançada de Banco de Dados
* Processamento Assíncrono
* Sistemas Distribuídos
* Integração com Inteligência Artificial
* Engenharia de Dados
* Escalabilidade
* Performance
* Clean Architecture
* Domain-Driven Design (DDD)

Seu propósito é simular a complexidade técnica encontrada em plataformas profissionais de recrutamento, combinando automação, análise de dados e IA para oferecer uma experiência moderna e inteligente na busca por oportunidades de trabalho.
