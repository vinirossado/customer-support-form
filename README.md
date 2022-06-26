# Customer Support Form
Project to create a sample of customer contact form.
- Frontend: Angular 13
- Backend: .Net 6

# Requirements
- Docker
- Docker Compose


# Tests
- Open customer-support-form/web
- On bash terminal execute ``` npm install && npm run build && npm run test ```

# Usage on Windows and Linux
- Open root folder (CustomerSupportForm) and find a docker-compose.yml
- Run  Docker Compose using ``` "docker-compose up -d" ```
- After running the command and the project is up and running open a browser and navigate to http://localhost:4200/
 
# Thoughts about Improvement on API
- Implements UoW (Unit of Work)
- Implements logging on Error handling middleware and save it on mongoDb
- Implements usage of environments settings
- Implements E2E tests

# Thoughts about Improvement on Front
- Implements better ways to return feedback to customer
- Create some kind of toast to return a feedback


