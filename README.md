# 📘 Avaliação Técnica – Clean Architecture + SQL Server

Este repositório contém minha entrega referente à avaliação técnica baseada no repositório original do professor:  
[https://github.com/victoricoma/avaliacao-tp2-helpapp](https://github.com/victoricoma/avaliacao-tp2-helpapp)

---

## ✅ Objetivo

Implementar os repositórios `Category` e `Product` seguindo os padrões da Clean Architecture, aplicar a migration `Initial` e conectar a aplicação com uma instância de SQL Server.

---

## 🚀 Funcionalidades implementadas

- [x] Repositórios `CategoryRepository` e `ProductRepository`
- [x] Configurações com `EntityTypeConfiguration` para `Category` e `Product`
- [x] Injeção de dependência configurada (`DependencyInjectionAPI`)
- [x] Migration `Initial` criada com `HasData()` para categorias
- [x] Banco de dados SQL Server criado localmente
- [x] Migration aplicada com sucesso no SQL via `Package Manager Console`

---
# 🔧 Comandos utilizados
## Criação da migration
```
Add-Migration Initial
```

## Aplicação no banco de dados (SQL)
```
Update-Database
```


# 🔗 String de conexão (mascarada)
```
"ConnectionStrings": {
  "DefaultConnection": "Data Source=DESKTOP-F68GVQT\\SQLEXPRESS;Initial Catalog=avalicaomigueltp2;Integrated Security=True;Trust Server Certificate=True;"
}
```

# ☁️ Configuração no Banco de Dados Local
Database criado no SQL Server através do comando:
```
CREATE DATABASE avalicaomigueltp2;
```

Banco de dados nomeado: **avaliacaomigueltp2**

Autenticação Integrada ao **Windows**

# 🖼️ Prints de evidência

## I. Testes Unitários 
_Testes Unitários de **Category** e **Product** funcionando corretamente._
![image](https://github.com/user-attachments/assets/875ae1c9-29e6-4df6-96fd-758a898a6759)

## II. Conexão com o Bando de Dados SQL
_String de conexão configurada no `appsettings.json`_
![image](https://github.com/user-attachments/assets/03e5d0e3-b164-4603-bda7-24d2bc11de81)

## III. Inserindo Dados de `Category`
_Dados inseridos na tabela Categories._
![image](https://github.com/user-attachments/assets/ed3583bc-68bd-44da-b714-2c4dab272af3)

## IV. Migration Initial
_Migration Initial criada pelo `Package Manager Console`, através do comando:_
```
Add-Migration Initial
```
_E posteriormente atualizado no Banco de Dados SQL através do comando:_
```
Update-Database
```
![image](https://github.com/user-attachments/assets/019560f9-439c-417c-a00d-f460cc6f1284)

## V. Resultado no Banco de Dados SQL
_Colunas criadas corretamente:_

![image](https://github.com/user-attachments/assets/171c8600-78de-461d-834b-a5405db1e707)

_Dados Adicionados corretamente:_

![image](https://github.com/user-attachments/assets/c7b452ab-22e2-4567-965f-2abdc9f6269b) 

![image](https://github.com/user-attachments/assets/e2ed222f-2b13-4315-a7fa-160b93b4c47a)

_Migration adicionadas com sucesso:_

![image](https://github.com/user-attachments/assets/2f9976cc-de8e-479a-9d57-4a6ea99211c7)

_Diagrama do Banco de Dados SQL:_

![image](https://github.com/user-attachments/assets/93321837-49a5-4324-8fad-2c196f8f461f)


# 👨‍💻 Dados do aluno
Nome: Miguel Miranda Morandini

Curso: Desenvolvimento de Software Multiplataforma – 3º Semestre

Professor: Victor Icoma

Branch da entrega: avaliacao-miguelmorandini

## 🧱 Estrutura da aplicação

```bash
📦 HelpApp
 ┣ 📂 API
 ┣ 📂 Application
 ┣ 📂 Domain
 ┣ 📂 Domain.Test
 ┣ 📂 Infra.Data
 ┃ ┣ 📂 Context
 ┃ ┣ 📂 EntitiesConfiguration
 ┃ ┗ 📂 Migrations
 ┃ ┗ 📂 Repositories
 ┗ 📂 Infra.IoC

