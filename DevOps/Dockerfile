# Use an official Node.js LTS image
FROM node:22-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy package files first
COPY package*.json ./

# Install production dependencies
RUN npm ci --omit=dev

# Copy the application source code
COPY . .

# Document the application port
EXPOSE 3000

# Start the Express application
CMD ["node", "HelloWorldWebApp.js"]
