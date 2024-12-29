import mitt from 'mitt'

export {}

declare module 'vue' {
  interface ComponentCustomProperties {
    $emitter: mitt.Emitter<any>
  }
}
