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

import { FSButtonsAliases, FSButtonsProps } from "@dative-gpi/foundation-shared-components/aliases";

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
  aliases: {
    ...FSButtonsAliases,
  },
  defaults: {
    ...FSButtonsProps
  }
})
