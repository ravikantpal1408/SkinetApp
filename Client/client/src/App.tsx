import React from 'react';
import logo from './logo.svg';
import './App.css';
import Button from './Component/Button/Button';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <h1>Hello there we have strated React Building block of app</h1>
        <Button/>
      </header>
    </div>
  );
}

export default App;
