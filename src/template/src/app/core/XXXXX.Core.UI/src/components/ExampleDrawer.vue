<template>
    <drawer :title="title" :width="width" v-model="drawer">
      <template #default>
        <div class="mb-5">
          <div>
            You can set the drawer's width programatically :
          </div>
  
          <v-row no-gutters>
            <d-btn @click="width = 300" right>Set width to 300px</d-btn>
            <d-btn @click="width = 500" right>Set width to 500px</d-btn>
          </v-row>
        </div>
  
        <div class="mb-5">
          <v-form>
            <div>
              Drawers usually contain forms to create or update entities. Here you
              can create an Example entity.
            </div>
  
            <d-text-field :editable="true" v-model="label" />
          </v-form>
        </div>
  
        <div class="mb-5">
          <v-row no-gutters>
            <d-btn @click="items = []">
              {{ $tr("ui.example.reset-height", "Reset height") }}
            </d-btn>
            <d-btn @click="increaseHeight">
              {{ $tr("ui.example.increase-height", "Increase height") }}
            </d-btn>
          </v-row>
  
          <div v-for="item in items" :key="item" class="text-h1">
            {{ item }}
          </div>
        </div>
      </template>
  
      <template #actions>
        <v-spacer />
        <d-btn @click="onSuccess" :loading="creating" right>
          {{ $tr("ui.common.create", "Create") }}
        </d-btn>
      </template>
    </drawer>
  </template>
  
  <script lang="ts">
  import { DependencyContainer } from "tsyringe";
  import { Component, Inject, Vue } from "vue-property-decorator";
  
  import { ORGANISATION, PROVIDER, SERVICES as S } from "@/config";
  import { IExampleService } from "@/interfaces";
  import Drawer from "@/components/shared/Drawer.vue";
  
  @Component({
    components: {
      Drawer,
    },
  })
  export default class ExampleDrawer extends Vue {
    // Properties
  
    @Inject(PROVIDER)
    container!: DependencyContainer;
  
    @Inject(ORGANISATION)
    organisationId!: string;
  
    // Data
  
    drawer = true;
    creating = false;
    title = "My Drawer";
    width = 256;
  
    items: any[] = [];
    label = "example";
  
    // Computed Properties
  
    get exempleService() {
      return this.container.resolve<IExampleService>(S.EXAMPLESERVICE);
    }
  
    // Methods
  
    increaseHeight() {
      length = this.items.length;
      for (let i = length; i < length + 10; i++) {
        this.items.push(i);
      }
    }
  
    async onSuccess() {
      this.creating = true;
  
      try {
        await this.exempleService.create(this.organisationId, {
          label: this.label,
        });
        this.drawer = false;
      } finally {
        this.creating = false;
      }
    }
  
    // Lifecycle
  }
  </script>