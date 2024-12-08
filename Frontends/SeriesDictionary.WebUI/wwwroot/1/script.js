window.addEventListener("load", () => {
  const helpButton = document.querySelector(".memo")
  const helpModal = document.querySelector(".modal")
  const closeHelpModal = document.querySelector(".modal-close")
  const vellum = document.querySelector(".vellum")
  let generatedMarkup = ""

  helpButton &&
    helpModal &&
    closeHelpModal &&
    [helpButton, closeHelpModal].map((button) =>
      button.addEventListener("click", () => {
        helpModal.classList.toggle("modal-open")
      })
    )

  // async function sleep(ms) {
  //   return new Promise((resolve) => setTimeout(resolve, ms))
  // }

  async function playAudio(src) {
    const audio = new Audio(src)
    const audioExtension = src.split(".")[1]
    const mimeTypeMapping = {
      flac: "audio/flac",
      m3u: "audio/mpegurl",
      m3u8: "audio/mpegurl",
      m4a: "audio/mp4",
      m4b: "audio/mp4",
      mp3: "audio/mpeg",
      ogg: "audio/ogg",
      opus: "audio/ogg",
      pls: "audio/x-scpls",
      wav: "audio/wav",
      webm: "audio/webm",
      wma: "audio/x-ms-wma",
      xspf: "application/xspf+xml",
    }

    if (audioExtension) {
      audio.type = mimeTypeMapping[audioExtension]

      try {
        await audio.play()
      } catch (error) {
        console.error(error.message)
      }
    }
  }

  function playAndAnimateTrumpet(trumpetElement) {
    playAudio(trumpetElement.nextElementSibling.src)

    trumpetElement.classList.add("raise")

    setTimeout(() => trumpetElement.classList.remove("raise"), 1200)
  }

  if (vellum) {
    vellum.classList.add("loading")
  }

  ;(async () => {
    try {
      // await sleep(50000)
      const promise = await fetch("db.json")
      const result = await promise.json()

      result &&
        Object.keys(result).map((category) => {
          let rowsForCategory = ""

          result[category].length > 0 &&
            result[category].map(({ en, tone, he, audio }) => {
              // sometimes 'audio' is an array of URLs
              const audioFile = Array.isArray(audio) ? audio[0] : audio

              let audioElement = ""

              if (audioFile) {
                audioElement = `
                  <audio class="audio" src="${audioFile}">
                    Your browser does not support the <code>audio</code> element.
                  </audio>
                `
              }

              rowsForCategory += `
                <div class="flex bbd">
                  <p class="px-2 text-4xl">${en}</p>
                  <p class="px-2 text-4xl">
                    <svg
                      width="24"
                      height="24"
                      xmlns="http://www.w3.org/2000/svg"
                      fill-rule="evenodd"
                      clip-rule="evenodd"
                      class="trumpet pointer"
                      tabindex="0"
                    >
                      <path
                        d="M15 23l-9.309-6H0V7h5.691L15 1v22zM6 7.991v8.018l8 5.157V2.834L6 7.991zm14.228-4.219A10.779 10.779 0 0124 12.001a10.78 10.78 0 01-3.77 8.229l-.708-.708C21.658 17.731 23 15.021 23 12s-1.342-5.731-3.478-7.522l.706-.706zm-2.929 2.929A6.848 6.848 0 0119.775 12a6.848 6.848 0 01-2.476 5.299l-.706-.706a5.861 5.861 0 002.182-4.591 5.861 5.861 0 00-2.184-4.593l.708-.708zM5 8H1v8h4V8z"
                      />
                    </svg>
                    ${audioElement}
                    <span class="text-italic">${tone}</span>
                  </p>
                  <p class="he px-2 text-4xl">
                    <span>${he}</span>
                    <span class="north-west-arrow" title="Collapse the '${category}' group.">&#8598;</span>
                  </p>
                </div>
              `

              return rowsForCategory
            })

          generatedMarkup += `
            <details>
              <summary class="text-4xl text-center pointer capitalize">
                ${category}
              </summary>
              ${rowsForCategory}
            </details>
          `
          return generatedMarkup
        })

      if (vellum) {
        vellum.classList.remove("loading")

        vellum.insertAdjacentHTML("afterend", generatedMarkup)
      }

      ;[...document.querySelectorAll(".trumpet")].map((trumpetIcon) => {
        if (
          trumpetIcon.nextElementSibling.classList.contains("audio") &&
          trumpetIcon.nextElementSibling.src !== location.href
        ) {
          // TODO: use event delegation everywhere, https://stackoverflow.com/a/20866519
          trumpetIcon.addEventListener("click", () =>
            playAndAnimateTrumpet(trumpetIcon)
          )

          trumpetIcon.addEventListener(
            "keydown",
            (e) => e.keyCode === 13 && playAndAnimateTrumpet(trumpetIcon)
          )
        } else {
          trumpetIcon.classList.add("mute")
        }
      })
      ;[...document.querySelectorAll(".north-west-arrow")].map((arrow) =>
        arrow.addEventListener("click", function () {
          this.parentElement.parentElement.parentElement.removeAttribute("open")
        })
      )
    } catch (e) {
      console.error(e.message)
    }
  })()
})
