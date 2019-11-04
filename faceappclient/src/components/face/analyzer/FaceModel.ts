export interface Point {
    x: number,
    y: number
}

export interface Rectangle {
    width: number,
    height: number, 
    left: number, 
    top: number
}

export interface FaceModel {
    faceId: string,
    faceRectangle: Rectangle,
    faceLandmarks: any,
    faceAttributes: any
}