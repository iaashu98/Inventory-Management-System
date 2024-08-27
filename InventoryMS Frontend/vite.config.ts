import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: 'localhost', // or 'localhost' for local development
    port: 3000, // Change this to your desired port
    open: true, // Automatically open the browser when the server starts
  },
})
