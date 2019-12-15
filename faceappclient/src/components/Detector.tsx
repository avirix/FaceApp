import React from 'react';
import { ImageUpload } from './face/ImageUpload';

export class Detector extends React.Component<{}>{
    render = () =>
        <div className = "jumbotron">
            <ImageUpload />
        </div>
}