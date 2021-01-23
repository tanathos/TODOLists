<template>
  <div class="xl:w-6/12" style="margin:auto">
    <div class="field">
      <label for="title">Title</label>
      <input id="title" v-model="newTodo.title" type="text" class="w-full" @keypress.enter="onEnter">
    </div>
    <div class="field">
      <label for="title">Description</label>
      <textarea id="title" v-model="newTodo.description" class="w-full" rows="5" @keypress.enter="onEnterArea" />
    </div>

    <button id="createTodo" class="p-2" @click="onCreateClick">
      Create
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "nuxt-property-decorator";

@Component
export default class CreateTodo extends Vue {
  newTodo: any = { title: "" };

  async onCreateClick () {
    try {
      const res = await this.$axios.$post(`/todoapi/todos/`, { title: this.newTodo.title, description: this.newTodo.description });
      this.$router.push({ path: `/todos/${res.id}` });
    } catch (error) {
      console.error(error);
    }
  }

  onEnter () {
    this.onCreateClick();
  }

  onEnterArea (e) {
    switch (e.keyCode) {
      case 13:
        if (e.shiftKey) {
          console.log('shift enter');
          break;
        }
        e.preventDefault();
        this.onCreateClick();
        break;
    }
  }
}
</script>

<style>

</style>
