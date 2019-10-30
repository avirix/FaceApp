import React, { FunctionComponent, useState } from 'react';

interface ImageInfoProps {
    data: string
}

const ImageInfo: FunctionComponent<ImageInfoProps> = (props) => {
    return (
        <div>
            <p className="text-break">{props.data}</p>
        </div>
    );
}

export default ImageInfo;