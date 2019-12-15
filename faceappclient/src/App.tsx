import React from 'react';
import  Header  from './components/Header';
import { Switch, Route } from 'react-router';
import { Detector } from './components/Detector';
import { Login } from './components/Login';
import { Home } from './components/Home';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import icon from './resources/img/icon.png';


export const App: React.FC = () => {
  return (
    <div className="background">
      <header className="navbar navbar-expand-lg navbar-dark">
          <a className="logo" href="/"><img src={icon} className="logo" alt="app logo"/></a>
        <a className="navbar-brand" href="/">Face<span>App</span></a>
        <Header />
      </header>
      <div className="container">
      <Switch>
        <Route exact path='/' component={Home} />
        <Route exact path='/detector' component={Detector} />
        <Route exact path='/login' component={Login} />
      </Switch>
      </div>
    </div>
  );
}

