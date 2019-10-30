import React from 'react';
import ImageUpload from './face/ImageUpload';

class Detector extends React.Component<{}>{
    render = () =>
        <div>
            Detector component
            <ImageUpload />
        </div>
}

export default Detector;