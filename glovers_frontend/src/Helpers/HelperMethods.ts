export default class HelperMethods {
  public uppercaseFirstLetter(text: string): string {
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
