import React from "react";
import "./index.css";
import { BrowserRouter } from 'react-router-dom'
import { ApplicationViews } from "./components/ApplicationViews.jsx";
import { Header } from "./components/Header.jsx";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Header />
        <ApplicationViews />
      </BrowserRouter>
    </div>
  )
}

export default App;