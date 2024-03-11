/**
 * plugins/vuetify.ts
 *
 * Framework documentation: https://vuetifyjs.com`
 */

// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

import "@dative-gpi/foundation-core-components/styles/main.scss";

import { DefaultTheme } from "@dative-gpi/foundation-shared-components/themes";
import { Flags } from "@dative-gpi/foundation-shared-components/icons/sets";

// Composables
import { createVuetify } from 'vuetify'

// https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
export default createVuetify({
  theme: {
    defaultTheme: "DefaultTheme",
    themes: {
      DefaultTheme
    }
  },
  icons: {
    defaultSet: "mdi",
    aliases: {
      ...Flags
    }
  }
})
