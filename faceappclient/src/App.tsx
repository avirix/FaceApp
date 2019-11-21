import React from 'react';
import { Header } from './components/Header';
import { Switch, Route } from 'react-router';
import { Detector } from './components/Detector';
import { Login } from './components/Login';
import { Home } from './components/Home';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';

export const App: React.FC = () => {
  return (
    <div className="container">
      <header className="navbar navbar-expand-lg navbar-dark bg-dark">
        <a className="navbar-brand" href="/">FaceApp</a>
        <Header />
      </header>
      <Switch>
        <Route exact path='/' component={Home} />
        <Route exact path='/detector' component={Detector} />
        <Route exact path='/login' component={Login} />
      </Switch>
    </div>
  );
}

