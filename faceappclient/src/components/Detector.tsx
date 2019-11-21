import React from 'react';
import { ImageUpload } from './face/ImageUpload';

export class Detector extends React.Component<{}>{
    render = () =>
        <div>
            <ImageUpload />
        </div>
}