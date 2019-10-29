  
import React from 'react';
import { Link } from 'react-router-dom';

const Header: React.FC = () => {
    return (
        <div className="navbar-collapse">
            <ul className="navbar-nav">
                <li className="nav-item"><Link className="nav-link" to='/detector'>Detector</Link></li>
            </ul>
        </div>
    );
}

export default Header;