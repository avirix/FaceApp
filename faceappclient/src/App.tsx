import React from 'react';
import './App.css';
import Header from './components/Header';
import { Switch, Route } from 'react-router';
import Detector from './components/Detector';

const App: React.FC = () => {
  return (
    <div className="container">
      <header className="navbar navbar-expand-lg navbar-dark bg-dark" style={{ marginBottom: '20px' }}>
        <a className="navbar-brand" href="/">FaceApp</a>
        <Header />
      </header>
      <Switch>
        <Route exact path='/' component={Detector} />
      </Switch>
    </div>
  );
}

export default App;
