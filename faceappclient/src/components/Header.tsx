import React from 'react';
import { Link } from 'react-router-dom';

export const Header: React.FC = () => {
    return (
        <div className="collapse navbar-collapse">
            <ul className="navbar-nav mr-auto">
                <li className="nav-item"><Link className="nav-link" to='/detector'>Detector</Link></li>
            </ul>
            <form className="form-inline my-2 my-lg-0">
                <input className="form-control mr-sm-2" type="email" placeholder="Email" aria-label="Email" />
                <input className="form-control mr-sm-2" type="password" placeholder="Password" aria-label="Password" />
                <Link className="btn btn-success" to='/login'>Login</Link>
            </form>
        </div>
    );
}