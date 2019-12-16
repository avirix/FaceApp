import React, {Fragment} from 'react';
import {Link, NavLink} from 'react-router-dom';

interface HeaderElementsState {
    isShow: boolean
}

export class Header extends React.Component<{}, HeaderElementsState> {
    state = {
        isShow: false,
    };

    showHeader(e: any) {
        if (this.state.isShow) {
            this.setState({isShow: false});
        } else {
            this.setState({isShow: true});
        }
    };

    render() {
        const {isShow} = this.state;
        return (
            <Fragment>
                <button className="navbar-toggler collapsed" type="button" onClick={this.showHeader}>
                    <span className="navbar-toggler-icon"> </span>
                </button>
                <div className={isShow ? 'collapse navbar-collapse show' : 'collapse navbar-collapse'}>
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item"><NavLink className="nav-link" to='/detector'>Detector</NavLink></li>
                    </ul>
                    <form className="form-inline my-2 my-lg-0">
                        <input className="form-control mr-sm-2" type="email" placeholder="Email" aria-label="Email"/>
                        <input className="form-control mr-sm-2" type="password" placeholder="Password"
                               aria-label="Password"/>
                        <Link className="d-md-inline-block btn btn-outline-primary" to='/login'>Login</Link>
                    </form>
                </div>
            </Fragment>
        );
    }
}