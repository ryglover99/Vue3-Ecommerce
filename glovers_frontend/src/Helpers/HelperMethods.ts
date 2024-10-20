export default class HelperMethods {
  public uppercaseFirstLetter(text: string | undefined): string {
    if (!text) return ''

    let newTextArray: string[] = []

    text.split(' ').forEach((word) => {
      let placeHolderOfChars = [...word]
      placeHolderOfChars[0] = placeHolderOfChars[0].toUpperCase()
      newTextArray.push(placeHolderOfChars.join(''))
    })

    return newTextArray.join(' ')
  }

  public scrollToTop() {
    window.scroll(0, 0)
  }
}
