import React from 'react';
import { Header } from './components/Header';
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
        <img src={icon} className="logo"/>
        <a className="navbar-brand" href="/">Face<span>App</span></a>
        <button className="navbar-toggler collapsed" type="button">
          <span className="navbar-toggler-icon"></span>
        </button>
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

